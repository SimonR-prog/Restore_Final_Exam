
import { umbExtensionsRegistry } from '@umbraco-cms/backoffice/extension-registry';






export const onInit = () => {
    umbExtensionsRegistry.exclude('umb-light-theme');
    umbExtensionsRegistry.exclude('umb-dark-theme');
    umbExtensionsRegistry.exclude('umb-high-contrast-theme');
}