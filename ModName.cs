using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Modding;
using UnityEngine.SceneManagement;
namespace ModTemplate
{
    public class ModName : Mod//,ITogglableMod
    {
        public override void Initialize()
        {
            
        }
        public void Unload() // finish this and implement ITogglableMod interface
        {

        }
        
        public override string GetVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            string ver = asm.GetName().Version.ToString();

            using SHA1 sha1 = SHA1.Create();
            using FileStream stream = File.OpenRead(asm.Location);

            byte[] hashBytes = sha1.ComputeHash(stream);

            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

            return $"{ver}-{hash.Substring(0, 6)}";
        }

        //public GlobalModSettings Settings = new GlobalModSettings();
        /*
        public override ModSettings GlobalSettings
        {
            get => Settings;
            set => Settings = (GlobalModSettings)value;
        }
        */
    }
}
