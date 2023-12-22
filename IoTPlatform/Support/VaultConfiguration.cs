using System.Reflection;
using IoTPlatform.Classes.Consts;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace IoTPlatform.Support
{
    public static class VaultConfiguration
    {
        public static async Task<IConfiguration> AddVault(this IConfiguration configuration)
        {
            var vaultClientToken = configuration.GetSection(EnvironmentConsts.VAULT_TOKEN).Value;
            IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultClientToken);

            var vaultClientSettings = new VaultClientSettings(configuration.GetSection(EnvironmentConsts.VAULT_CONNECTION_STRING).Value, authMethod);
            var vaultClient = new VaultClient(vaultClientSettings);

            var secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync<MongoDBSettings>(
                path: configuration.GetSection(EnvironmentConsts.VAULT_MONGODB_SETTINGS_PATH).Value, mountPoint: "kv");
            MongoDBSettings mongoDBSettings = secret.Data.Data;

            var fieldInfo = typeof(MongoDBSettings).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var field in fieldInfo)
            {
                configuration[field.Name] = typeof(MongoDBSettings).GetProperty(field.Name, BindingFlags.Instance | BindingFlags.Public).GetValue(mongoDBSettings, null).ToString();
            }
            return configuration;
        }
    }
}
