using Zenject;

namespace _PocketZone.Scripts.ModuleUtilities
{
    public class UtilitiesModuleInstaller : Installer<UtilitiesModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterMovement>().AsSingle();
        }
    }
}