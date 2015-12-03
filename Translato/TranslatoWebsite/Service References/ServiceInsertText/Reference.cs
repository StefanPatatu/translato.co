﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TranslatoWebsite.ServiceInsertText {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Text", Namespace="http://schemas.datacontract.org/2004/07/TranslatoServiceLibrary.MODEL")]
    [System.SerializableAttribute()]
    public partial class Text : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string textDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int textIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string textData {
            get {
                return this.textDataField;
            }
            set {
                if ((object.ReferenceEquals(this.textDataField, value) != true)) {
                    this.textDataField = value;
                    this.RaisePropertyChanged("textData");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int textId {
            get {
                return this.textIdField;
            }
            set {
                if ((this.textIdField.Equals(value) != true)) {
                    this.textIdField = value;
                    this.RaisePropertyChanged("textId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceInsertText.IServiceInsertText")]
    public interface IServiceInsertText {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceInsertText/insertText", ReplyAction="http://tempuri.org/IServiceInsertText/insertTextResponse")]
        int insertText(TranslatoWebsite.ServiceInsertText.Text text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceInsertText/insertText", ReplyAction="http://tempuri.org/IServiceInsertText/insertTextResponse")]
        System.Threading.Tasks.Task<int> insertTextAsync(TranslatoWebsite.ServiceInsertText.Text text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceInsertTextChannel : TranslatoWebsite.ServiceInsertText.IServiceInsertText, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceInsertTextClient : System.ServiceModel.ClientBase<TranslatoWebsite.ServiceInsertText.IServiceInsertText>, TranslatoWebsite.ServiceInsertText.IServiceInsertText {
        
        public ServiceInsertTextClient() {
        }
        
        public ServiceInsertTextClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceInsertTextClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceInsertTextClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceInsertTextClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int insertText(TranslatoWebsite.ServiceInsertText.Text text) {
            return base.Channel.insertText(text);
        }
        
        public System.Threading.Tasks.Task<int> insertTextAsync(TranslatoWebsite.ServiceInsertText.Text text) {
            return base.Channel.insertTextAsync(text);
        }
    }
}
