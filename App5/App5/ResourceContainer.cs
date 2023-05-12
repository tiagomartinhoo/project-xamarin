using System.Globalization;
using System.Resources;

namespace App5
{
    public interface IResourceContainer
    {
        string GetString(string key);
    }

    public class ResourceContainer : IResourceContainer
    {
        public static string ResourceId = "App5.Res.Resources";


        private CultureInfo _cultureInfo;
        private ResourceManager _resourceManager;

        public ResourceContainer(ResourceManager manager, Localize localize)
        {
            _cultureInfo = localize.GetCurrentCultureInfo();
            _resourceManager = manager;
        }

        public string GetString(string key)
        {
            return _resourceManager.GetString(key, _cultureInfo);
        }
    }

    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }

    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentCulture;
        }
    }
}
