﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnD_Sheet.Resources.Views.Shared {
    using System;
    
    
    /// <summary>
    ///   Třída prostředků se silnými typy pro vyhledávání lokalizovaných řetězců atp.
    /// </summary>
    // Tato třída byla automaticky generována třídou StronglyTypedResourceBuilder
    // pomocí nástroje podobného aplikaci ResGen nebo Visual Studio.
    // Chcete-li přidat nebo odebrat člena, upravte souboru .ResX a pak znovu spusťte aplikaci ResGen
    // s parametrem /str nebo znovu sestavte projekt aplikace Visual Studio.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class _Layout {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal _Layout() {
        }
        
        /// <summary>
        ///   Vrací instanci ResourceManager uloženou v mezipaměti použitou touto třídou.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DnD_Sheet.Resources.Views.Shared._Layout", typeof(_Layout).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Potlačí vlastnost CurrentUICulture aktuálního vlákna pro všechna
        ///   vyhledání prostředků pomocí třídy prostředků se silnými typy.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Vyhledá lokalizovaný řetězec podobný Character Creator.
        /// </summary>
        public static string CharCreator {
            get {
                return ResourceManager.GetString("CharCreator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Vyhledá lokalizovaný řetězec podobný Dark Mode.
        /// </summary>
        public static string DarkMode {
            get {
                return ResourceManager.GetString("DarkMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Vyhledá lokalizovaný řetězec podobný Guides.
        /// </summary>
        public static string Guides {
            get {
                return ResourceManager.GetString("Guides", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Vyhledá lokalizovaný řetězec podobný Home Page.
        /// </summary>
        public static string HomePage {
            get {
                return ResourceManager.GetString("HomePage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Vyhledá lokalizovaný řetězec podobný Light Mode.
        /// </summary>
        public static string LightMode {
            get {
                return ResourceManager.GetString("LightMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Vyhledá lokalizovaný řetězec podobný Privacy Policy.
        /// </summary>
        public static string PrivacyPolicy {
            get {
                return ResourceManager.GetString("PrivacyPolicy", resourceCulture);
            }
        }
    }
}