﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportConnect.Core.Resources.LoginAndRegisterResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LoginAndRegisterResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoginAndRegisterResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SportConnect.Core.Resources.LoginAndRegisterResources.LoginAndRegisterResources", typeof(LoginAndRegisterResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We already have this email in our application.
        /// </summary>
        internal static string EmailAlreadyIsInApplication {
            get {
                return ResourceManager.GetString("EmailAlreadyIsInApplication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email is too short.
        /// </summary>
        internal static string EmailIsTooShort {
            get {
                return ResourceManager.GetString("EmailIsTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We already have this login in our application.
        /// </summary>
        internal static string LoginAlreadyIsInApplication {
            get {
                return ResourceManager.GetString("LoginAlreadyIsInApplication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login is too short.
        /// </summary>
        internal static string LoginIsTooShort {
            get {
                return ResourceManager.GetString("LoginIsTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login or password is not correct.
        /// </summary>
        internal static string LoginOrPasswordIsnMatch {
            get {
                return ResourceManager.GetString("LoginOrPasswordIsnMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email must contains @.
        /// </summary>
        internal static string NotValidEmailByNotContainAt {
            get {
                return ResourceManager.GetString("NotValidEmailByNotContainAt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must have 6 characters and at least one digit.
        /// </summary>
        internal static string PasswordIsNotValid {
            get {
                return ResourceManager.GetString("PasswordIsNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Both passwords must be the same.
        /// </summary>
        internal static string RepeatedPasswordIsNotAsPassword {
            get {
                return ResourceManager.GetString("RepeatedPasswordIsNotAsPassword", resourceCulture);
            }
        }
    }
}