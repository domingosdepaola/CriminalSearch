﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CriminalWebApp.CriminalServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CriminalServiceReference.IServiceCriminal")]
    public interface IServiceCriminal {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCriminal/DoWork", ReplyAction="http://tempuri.org/IServiceCriminal/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCriminal/DoWork", ReplyAction="http://tempuri.org/IServiceCriminal/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCriminal/SearchCriminalList", ReplyAction="http://tempuri.org/IServiceCriminal/SearchCriminalListResponse")]
        bool SearchCriminalList(string email, string searchTerm, string name, System.Nullable<int> ageStart, System.Nullable<int> ageEnd, System.Nullable<int> idSex, System.Nullable<int> idCountry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCriminal/SearchCriminalList", ReplyAction="http://tempuri.org/IServiceCriminal/SearchCriminalListResponse")]
        System.Threading.Tasks.Task<bool> SearchCriminalListAsync(string email, string searchTerm, string name, System.Nullable<int> ageStart, System.Nullable<int> ageEnd, System.Nullable<int> idSex, System.Nullable<int> idCountry);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCriminalChannel : CriminalWebApp.CriminalServiceReference.IServiceCriminal, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceCriminalClient : System.ServiceModel.ClientBase<CriminalWebApp.CriminalServiceReference.IServiceCriminal>, CriminalWebApp.CriminalServiceReference.IServiceCriminal {
        
        public ServiceCriminalClient() {
        }
        
        public ServiceCriminalClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceCriminalClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCriminalClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCriminalClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool SearchCriminalList(string email, string searchTerm, string name, System.Nullable<int> ageStart, System.Nullable<int> ageEnd, System.Nullable<int> idSex, System.Nullable<int> idCountry) {
            return base.Channel.SearchCriminalList(email, searchTerm, name, ageStart, ageEnd, idSex, idCountry);
        }
        
        public System.Threading.Tasks.Task<bool> SearchCriminalListAsync(string email, string searchTerm, string name, System.Nullable<int> ageStart, System.Nullable<int> ageEnd, System.Nullable<int> idSex, System.Nullable<int> idCountry) {
            return base.Channel.SearchCriminalListAsync(email, searchTerm, name, ageStart, ageEnd, idSex, idCountry);
        }
    }
}
