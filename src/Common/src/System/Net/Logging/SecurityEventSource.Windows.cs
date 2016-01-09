// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics.Tracing;

namespace System.Net
{
    internal sealed partial class SecurityEventSource : EventSource
    {
        [Event(ACQUIRE_DEFAULT_CREDENTIAL_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal void AcquireDefaultCredential(string packageName, Interop.SspiCli.CredentialUse intent)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            string arg1Str = "";
            if (packageName != null)
            {
                arg1Str = packageName;
            }
            s_log.WriteEvent(ACQUIRE_DEFAULT_CREDENTIAL_ID, arg1Str, intent);
        }

        [NonEvent]
        internal static void AcquireCredentialsHandle(string packageName, Interop.SspiCli.CredentialUse intent, object authdata)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            string arg1Str = "";
            if (packageName != null)
            {
                arg1Str = packageName;
            }
            s_log.AcquireCredentialsHandle(arg1Str, intent, LoggingHash.GetObjectName(authdata));
        }

        [Event(ACQUIRE_CREDENTIALS_HANDLE_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal unsafe void AcquireCredentialsHandle(string packageName, Interop.SspiCli.CredentialUse intent, string authdata)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            const int SIZEDATA = 3;
            fixed (char* arg1Ptr = packageName, arg2Ptr = authdata)
            {
                EventData* dataDesc = stackalloc EventSource.EventData[SIZEDATA];
                dataDesc[0].DataPointer = (IntPtr)(arg1Ptr);
                dataDesc[0].Size = (packageName.Length + 1) * sizeof(char);
                dataDesc[1].DataPointer = (IntPtr)(&intent);
                dataDesc[1].Size = sizeof(int);
                dataDesc[2].DataPointer = (IntPtr)(arg2Ptr);
                dataDesc[2].Size = (authdata.Length + 1) * sizeof(char);

                WriteEventCore(ACQUIRE_CREDENTIALS_HANDLE_ID, SIZEDATA, dataDesc);
            }
        }

        [Event(INITIALIZE_SECURITY_CONTEXT_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal unsafe void InitializeSecurityContext(string credential, string context, string targetName, Interop.SspiCli.ContextFlags inFlags)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            fixed (char* arg1Ptr = credential, arg2Ptr = context, arg3Ptr = targetName)
            {
                const int SIZEDATA = 4;
                EventData* dataDesc = stackalloc EventSource.EventData[SIZEDATA];
                dataDesc[0].DataPointer = (IntPtr)(arg1Ptr);
                dataDesc[0].Size = (credential.Length + 1) * sizeof(char);
                dataDesc[1].DataPointer = (IntPtr)(arg2Ptr);
                dataDesc[1].Size = (context.Length + 1) * sizeof(char);
                dataDesc[2].DataPointer = (IntPtr)(arg2Ptr);
                dataDesc[2].Size = (targetName.Length + 1) * sizeof(char);
                dataDesc[3].DataPointer = (IntPtr)(&inFlags);
                dataDesc[3].Size = sizeof(int);

                WriteEventCore(INITIALIZE_SECURITY_CONTEXT_ID, SIZEDATA, dataDesc);
            }
        }

        [Event(ACCEPT_SECURITY_CONTEXT_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal unsafe void AcceptSecurityContext(string credential, string context, Interop.SspiCli.ContextFlags inFlags)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            fixed (char* arg1Ptr = credential, arg2Ptr = context)
            {
                const int SIZEDATA = 3;
                EventData* dataDesc = stackalloc EventSource.EventData[SIZEDATA];
                dataDesc[0].DataPointer = (IntPtr)(arg1Ptr);
                dataDesc[0].Size = (credential.Length + 1) * sizeof(char);
                dataDesc[1].DataPointer = (IntPtr)(arg2Ptr);
                dataDesc[1].Size = (context.Length + 1) * sizeof(char);
                dataDesc[2].DataPointer = (IntPtr)(&inFlags);
                dataDesc[2].Size = sizeof(int);

                WriteEventCore(ACCEPT_SECURITY_CONTEXT_ID, SIZEDATA, dataDesc);
            }
        }

        [Event(OPERATION_RETURNED_SOMETHING_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal void OperationReturnedSomething(string operation, Interop.SecurityStatus errorCode)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            WriteEvent(OPERATION_RETURNED_SOMETHING_ID, operation, errorCode);
        }

        [Event(SECURITY_CONTEXT_INPUT_BUFFER_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal unsafe void SecurityContextInputBuffer(string context, int inputBufferSize, int outputBufferSize, Interop.SecurityStatus errorCode)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            fixed (char* arg1Ptr = context)
            {
                const int SIZEDATA = 4;
                EventData* dataDesc = stackalloc EventSource.EventData[SIZEDATA];
                dataDesc[0].DataPointer = (IntPtr)(arg1Ptr);
                dataDesc[0].Size = (context.Length + 1) * sizeof(char);
                dataDesc[1].DataPointer = (IntPtr)(&inputBufferSize);
                dataDesc[1].Size = sizeof(int);
                dataDesc[2].DataPointer = (IntPtr)(&outputBufferSize);
                dataDesc[2].Size = sizeof(int);
                dataDesc[3].DataPointer = (IntPtr)(&errorCode);
                dataDesc[3].Size = sizeof(int);

                WriteEventCore(SECURITY_CONTEXT_INPUT_BUFFER_ID, SIZEDATA, dataDesc);
            }
        }

        [Event(SECURITY_CONTEXT_INPUT_BUFFERS_ID, Keywords = Keywords.Default,
            Level = EventLevel.Informational)]
        internal unsafe void SecurityContextInputBuffers(string context, int inputBuffersSize, int outputBufferSize, Interop.SecurityStatus errorCode)
        {
            if (!s_log.IsEnabled())
            {
                return;
            }
            fixed (char* arg1Ptr = context)
            {
                const int SIZEDATA = 4;
                EventData* dataDesc = stackalloc EventSource.EventData[SIZEDATA];
                dataDesc[0].DataPointer = (IntPtr)(arg1Ptr);
                dataDesc[0].Size = (context.Length + 1) * sizeof(char);
                dataDesc[1].DataPointer = (IntPtr)(&inputBuffersSize);
                dataDesc[1].Size = sizeof(int);
                dataDesc[2].DataPointer = (IntPtr)(&outputBufferSize);
                dataDesc[2].Size = sizeof(int);
                dataDesc[3].DataPointer = (IntPtr)(&errorCode);
                dataDesc[3].Size = sizeof(int);

                WriteEventCore(SECURITY_CONTEXT_INPUT_BUFFERS_ID, SIZEDATA, dataDesc);
            }
        }
    }
}
