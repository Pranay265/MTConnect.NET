﻿// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MTConnect.Agents.Information
{
    public class MTConnectAgentInformation
    {
        public const string Filename = "agent.information.json";


        [JsonPropertyName("changeToken")]
        public string ChangeToken { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonIgnore]
        public string ComponentId
        {
            get
            {
                var id = Uuid;
                id = id.ToMD5Hash().Substring(0, 10);
                return $"agent_{id}";
            }
        }


        public MTConnectAgentInformation()
        {
            Uuid = Guid.NewGuid().ToString();
        }


        public static MTConnectAgentInformation Read(string path = null)
        {
            return Read<MTConnectAgentInformation>(path);
        }

        public static T Read<T>(string path = null) where T : MTConnectAgentInformation
        {
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Filename);
            if (!string.IsNullOrEmpty(path))
            {
                configurationPath = path;
                if (!Path.IsPathRooted(configurationPath))
                {
                    configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configurationPath);
                }
            }

            if (!string.IsNullOrEmpty(configurationPath))
            {
                try
                {
                    var text = File.ReadAllText(configurationPath);
                    if (!string.IsNullOrEmpty(text))
                    {
                        return JsonSerializer.Deserialize<T>(text);
                    }
                }
                catch { }
            }

            return null;
        }

        public void Save(string path = null)
        {
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Filename);
            if (path != null) configurationPath = path;

            // Update ChangeToken
            ChangeToken = Guid.NewGuid().ToString();

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(configurationPath, json);
            }
            catch { }
        }
    }
}