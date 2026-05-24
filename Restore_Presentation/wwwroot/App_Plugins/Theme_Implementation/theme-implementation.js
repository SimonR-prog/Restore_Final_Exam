
export function applyThemeCSS(themeName) {
    const existingLinks = document.querySelectorAll("link[data-custom-theme]");
    existingLinks.forEach(link => link.remove());

    const link = document.createElement("link");
    link.rel = "stylesheet";
    link.href = `/App_Plugins/Theme/${themeName}.css`;
    link.setAttribute("data-custom-theme", themeName);

    document.head.appendChild(link);
}

if (document.body) {
    applyThemeCSS('mobel-light');
} else {
    window.addEventListener('DOMContentLoaded', () => applyThemeCSS('mobel-light'), { once: true });
}