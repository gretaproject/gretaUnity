/**
 * Autogenerated by Thrift Compiler (0.9.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace thrift.gen_csharp
{
  public partial class ExternalCom {
    public interface Iface : SimpleCom.Iface {
      /// <summary>
      /// A method definition looks like C code. It has a return type, arguments,
      /// and optionally a list of exceptions that it may throw. Note that argument
      /// lists and exception lists are specified using the exact same syntax as
      /// field lists in struct or exception definitions.
      /// </summary>
      /// <param name="currentMessageId"></param>
      Message update(string currentMessageId);
      #if SILVERLIGHT
      IAsyncResult Begin_update(AsyncCallback callback, object state, string currentMessageId);
      Message End_update(IAsyncResult asyncResult);
      #endif
      bool isNewMessage(string id);
      #if SILVERLIGHT
      IAsyncResult Begin_isNewMessage(AsyncCallback callback, object state, string id);
      bool End_isNewMessage(IAsyncResult asyncResult);
      #endif
    }

    public class Client : SimpleCom.Client, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot) : base(iprot, oprot)
      {
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_update(AsyncCallback callback, object state, string currentMessageId)
      {
        return send_update(callback, state, currentMessageId);
      }

      public Message End_update(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_update();
      }

      #endif

      /// <summary>
      /// A method definition looks like C code. It has a return type, arguments,
      /// and optionally a list of exceptions that it may throw. Note that argument
      /// lists and exception lists are specified using the exact same syntax as
      /// field lists in struct or exception definitions.
      /// </summary>
      /// <param name="currentMessageId"></param>
      public Message update(string currentMessageId)
      {
        #if !SILVERLIGHT
        send_update(currentMessageId);
        return recv_update();

        #else
        var asyncResult = Begin_update(null, null, currentMessageId);
        return End_update(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_update(AsyncCallback callback, object state, string currentMessageId)
      #else
      public void send_update(string currentMessageId)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("update", TMessageType.Call, seqid_));
        update_args args = new update_args();
        args.CurrentMessageId = currentMessageId;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public Message recv_update()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        update_result result = new update_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "update failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_isNewMessage(AsyncCallback callback, object state, string id)
      {
        return send_isNewMessage(callback, state, id);
      }

      public bool End_isNewMessage(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_isNewMessage();
      }

      #endif

      public bool isNewMessage(string id)
      {
        #if !SILVERLIGHT
        send_isNewMessage(id);
        return recv_isNewMessage();

        #else
        var asyncResult = Begin_isNewMessage(null, null, id);
        return End_isNewMessage(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_isNewMessage(AsyncCallback callback, object state, string id)
      #else
      public void send_isNewMessage(string id)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("isNewMessage", TMessageType.Call, seqid_));
        isNewMessage_args args = new isNewMessage_args();
        args.Id = id;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public bool recv_isNewMessage()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        isNewMessage_result result = new isNewMessage_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "isNewMessage failed: unknown result");
      }

    }
    public class Processor : SimpleCom.Processor, TProcessor {
      public Processor(Iface iface) : base(iface)
      {
        iface_ = iface;
        processMap_["update"] = update_Process;
        processMap_["isNewMessage"] = isNewMessage_Process;
      }

      private Iface iface_;

      public new bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void update_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        update_args args = new update_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        update_result result = new update_result();
        result.Success = iface_.update(args.CurrentMessageId);
        oprot.WriteMessageBegin(new TMessage("update", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void isNewMessage_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        isNewMessage_args args = new isNewMessage_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        isNewMessage_result result = new isNewMessage_result();
        result.Success = iface_.isNewMessage(args.Id);
        oprot.WriteMessageBegin(new TMessage("isNewMessage", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class update_args : TBase
    {
      private string _currentMessageId;

      public string CurrentMessageId
      {
        get
        {
          return _currentMessageId;
        }
        set
        {
          __isset.currentMessageId = true;
          this._currentMessageId = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool currentMessageId;
      }

      public update_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case -1:
              if (field.Type == TType.String) {
                CurrentMessageId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("update_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (CurrentMessageId != null && __isset.currentMessageId) {
          field.Name = "currentMessageId";
          field.Type = TType.String;
          field.ID = -1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CurrentMessageId);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("update_args(");
        sb.Append("CurrentMessageId: ");
        sb.Append(CurrentMessageId);
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class update_result : TBase
    {
      private Message _success;

      public Message Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public update_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Struct) {
                Success = new Message();
                Success.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("update_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.Struct;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            Success.Write(oprot);
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("update_result(");
        sb.Append("Success: ");
        sb.Append(Success== null ? "<null>" : Success.ToString());
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class isNewMessage_args : TBase
    {
      private string _id;

      public string Id
      {
        get
        {
          return _id;
        }
        set
        {
          __isset.id = true;
          this._id = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool id;
      }

      public isNewMessage_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case -1:
              if (field.Type == TType.String) {
                Id = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("isNewMessage_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Id != null && __isset.id) {
          field.Name = "id";
          field.Type = TType.String;
          field.ID = -1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Id);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("isNewMessage_args(");
        sb.Append("Id: ");
        sb.Append(Id);
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class isNewMessage_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public isNewMessage_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("isNewMessage_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.Bool;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("isNewMessage_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }

  }
}