﻿using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Core
{
    public class PublicKeyServer
    {
        [JsonProperty(PropertyName = "server_public_key")]
        public string ServerPublicKey { get; private set; }

        public PublicKeyServer(string serverPublicKey)
        {
            ServerPublicKey = serverPublicKey;
        }
    }
}