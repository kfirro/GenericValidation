using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FluentValidation;

namespace GenericValidation.Config
{
    public sealed class ConfigManager : IConfigEntity
    {
        //TODO: Implement caching
        //public const string CONFIG_FILE = @"Rules_Config.xml";
        private const string CONFIG_FILE = @"C:\Users\kfir\Documents\visual studio 2015\Projects\Validation\SiteValidation\Rules_Config.xml";
        private const string BOOL_DEFAULT_VALUE = "false";
        private const string INT_DEFAULT_VALUE = "-1";
        public List<IWrapper> Wrappers { get; private set; }
        public ConfigManager()
        {
            Wrappers = LoadConfig();
        }
        public IConfigField GetAbstractValidatorByName(string wrapperName, string fieldName)
        {
            //TODO: Use wrapper Name also
            var res = Wrappers.SelectMany(w => w.Wrappers).
                SelectMany(f => f.Fields).
                Where(f => f.Name.Equals(fieldName)).
                FirstOrDefault();
            return res;
        }
        private List<IWrapper> LoadConfig()
        {
            List<IWrapper> wrappers = new List<IWrapper>();
            //Do not try-catch it in order to get exception when config file is corrupted / missing
            XmlDocument doc = new XmlDocument();
            doc.Load(CONFIG_FILE);
            foreach (XmlNode row in doc.DocumentElement) //Sites / Apps / WebServices
            {
                if (row.Name.Equals("#comment"))
                    continue;
                //Sites
                var sites = row.ChildNodes;
                IWrapper wrapper = new ConfigSite();
                foreach (XmlNode site in sites)
                {
                    List<IFieldWrapper> fieldWrapperList = new List<IFieldWrapper>();
                    foreach (XmlNode page in site)
                    {
                        List<IConfigField> configFields = new List<IConfigField>();
                        foreach (XmlNode field in page)
                        {
                            //Get field with all of his properties
                            configFields.Add(new ConfigField()
                            {
                                MaxLength = GetIntAttribute(field.Attributes, "maxLength"),
                                MinLength = GetIntAttribute(field.Attributes, "minLength"),
                                Name = GetStringAttribute(field.Attributes, "name"),
                                PreventXSS = GetBoolAttribute(field.Attributes, "preventXSS"),
                                RegularExpression = GetStringAttribute(field.Attributes, "regularExpression"),
                                Required = GetBoolAttribute(field.Attributes, "required"),
                                ResourceKey = GetStringAttribute(field.Attributes, "resourceKey")
                            });
                        }
                        fieldWrapperList.Add(new ConfigPage() { Fields = configFields });
                    }
                    wrapper.Wrappers = fieldWrapperList;
                }
                wrappers.Add(wrapper);
            }

            return wrappers;
        }
        private int GetIntAttribute(XmlAttributeCollection attributes, string key)
        {
            var attr = attributes[key];
            int res;
            int.TryParse(attr?.Value ?? INT_DEFAULT_VALUE, out res);
            return res;
        }
        private string GetStringAttribute(XmlAttributeCollection attributes, string key)
        {
            var attr = attributes[key];
            return attr?.Value ?? string.Empty;
        }
        private bool GetBoolAttribute(XmlAttributeCollection attributes, string key)
        {
            var attr = attributes[key];
            bool res;
            bool.TryParse(attr?.Value ?? BOOL_DEFAULT_VALUE, out res);
            return res;
        }
    }
}
