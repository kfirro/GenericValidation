﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenericValidation.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class GenericValidation : global::System.Configuration.ApplicationSettingsBase {
        
        private static GenericValidation defaultInstance = ((GenericValidation)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new GenericValidation())));
        
        public static GenericValidation Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\kfir\\Source\\Repos\\GenericValidation\\SiteValidation\\Rules_Config.xml")]
        public string ConfigFilePath {
            get {
                return ((string)(this["ConfigFilePath"]));
            }
        }
    }
}
