﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExampleClient.MsdnDataBindingScenarioSampleClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WeatherData", Namespace="http://Microsoft.Samples.WindowsForms")]
    [System.SerializableAttribute()]
    public partial class WeatherData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HighTemperatureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LowTemperatureField;
        
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
        public int HighTemperature {
            get {
                return this.HighTemperatureField;
            }
            set {
                if ((this.HighTemperatureField.Equals(value) != true)) {
                    this.HighTemperatureField = value;
                    this.RaisePropertyChanged("HighTemperature");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Locality {
            get {
                return this.LocalityField;
            }
            set {
                if ((object.ReferenceEquals(this.LocalityField, value) != true)) {
                    this.LocalityField = value;
                    this.RaisePropertyChanged("Locality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LowTemperature {
            get {
                return this.LowTemperatureField;
            }
            set {
                if ((this.LowTemperatureField.Equals(value) != true)) {
                    this.LowTemperatureField = value;
                    this.RaisePropertyChanged("LowTemperature");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.Samples.WindowsForms", ConfigurationName="MsdnDataBindingScenarioSampleClient.IWeatherService")]
    public interface IWeatherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.WindowsForms/IWeatherService/GetWeatherData", ReplyAction="http://Microsoft.Samples.WindowsForms/IWeatherService/GetWeatherDataResponse")]
        ExampleClient.MsdnDataBindingScenarioSampleClient.WeatherData[] GetWeatherData(string[] localities);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWeatherServiceChannel : ExampleClient.MsdnDataBindingScenarioSampleClient.IWeatherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherServiceClient : System.ServiceModel.ClientBase<ExampleClient.MsdnDataBindingScenarioSampleClient.IWeatherService>, ExampleClient.MsdnDataBindingScenarioSampleClient.IWeatherService {
        
        public WeatherServiceClient() {
        }
        
        public WeatherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ExampleClient.MsdnDataBindingScenarioSampleClient.WeatherData[] GetWeatherData(string[] localities) {
            return base.Channel.GetWeatherData(localities);
        }
    }
}