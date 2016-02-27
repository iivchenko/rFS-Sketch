﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.WPF._FileSystemService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="FileSystemEntries", Namespace="http://schemas.datacontract.org/2004/07/Sketch.FileSystem", ItemName="FileSystemEntry")]
    [System.SerializableAttribute()]
    public class FileSystemEntries : System.Collections.Generic.List<Sketch.FileSystem.FileSystemEntry> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="_FileSystemService.IFileSystemService")]
    public interface IFileSystemService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/EnumerateEntries", ReplyAction="http://tempuri.org/IFileSystemService/EnumerateEntriesResponse")]
        Client.WPF._FileSystemService.FileSystemEntries EnumerateEntries(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/EnumerateEntries", ReplyAction="http://tempuri.org/IFileSystemService/EnumerateEntriesResponse")]
        System.Threading.Tasks.Task<Client.WPF._FileSystemService.FileSystemEntries> EnumerateEntriesAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/CreateDirectory", ReplyAction="http://tempuri.org/IFileSystemService/CreateDirectoryResponse")]
        void CreateDirectory(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/CreateDirectory", ReplyAction="http://tempuri.org/IFileSystemService/CreateDirectoryResponse")]
        System.Threading.Tasks.Task CreateDirectoryAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/DeleteDirectory", ReplyAction="http://tempuri.org/IFileSystemService/DeleteDirectoryResponse")]
        void DeleteDirectory(string path, bool recurs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/DeleteDirectory", ReplyAction="http://tempuri.org/IFileSystemService/DeleteDirectoryResponse")]
        System.Threading.Tasks.Task DeleteDirectoryAsync(string path, bool recurs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/DeleteFile", ReplyAction="http://tempuri.org/IFileSystemService/DeleteFileResponse")]
        void DeleteFile(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileSystemService/DeleteFile", ReplyAction="http://tempuri.org/IFileSystemService/DeleteFileResponse")]
        System.Threading.Tasks.Task DeleteFileAsync(string path);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileSystemServiceChannel : Client.WPF._FileSystemService.IFileSystemService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileSystemServiceClient : System.ServiceModel.ClientBase<Client.WPF._FileSystemService.IFileSystemService>, Client.WPF._FileSystemService.IFileSystemService {
        
        public FileSystemServiceClient() {
        }
        
        public FileSystemServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileSystemServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileSystemServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileSystemServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.WPF._FileSystemService.FileSystemEntries EnumerateEntries(string path) {
            return base.Channel.EnumerateEntries(path);
        }
        
        public System.Threading.Tasks.Task<Client.WPF._FileSystemService.FileSystemEntries> EnumerateEntriesAsync(string path) {
            return base.Channel.EnumerateEntriesAsync(path);
        }
        
        public void CreateDirectory(string path) {
            base.Channel.CreateDirectory(path);
        }
        
        public System.Threading.Tasks.Task CreateDirectoryAsync(string path) {
            return base.Channel.CreateDirectoryAsync(path);
        }
        
        public void DeleteDirectory(string path, bool recurs) {
            base.Channel.DeleteDirectory(path, recurs);
        }
        
        public System.Threading.Tasks.Task DeleteDirectoryAsync(string path, bool recurs) {
            return base.Channel.DeleteDirectoryAsync(path, recurs);
        }
        
        public void DeleteFile(string path) {
            base.Channel.DeleteFile(path);
        }
        
        public System.Threading.Tasks.Task DeleteFileAsync(string path) {
            return base.Channel.DeleteFileAsync(path);
        }
    }
}
