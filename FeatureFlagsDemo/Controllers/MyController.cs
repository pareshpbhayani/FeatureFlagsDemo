using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.VisualBasic;

namespace FeatureFlagsDemo.Controllers
{
    public class MyController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public MyController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<IActionResult> MyAction()
        {
            if (await _featureManager.IsEnabledAsync("NewFeature"))
            {
                // Feature is enabled, show the new functionality
                return View("NewFeature");
            }
            else
            {
                // Feature is disabled, show default behavior
                return View("Default");
            }
        }

        public IActionResult Default()
        {
            return View();
        }

        public IActionResult NewFeature()
        {
            return View();
        }
    }
}
