
export function changeFavicon() {

    // Removing old icons
    const oldIcons = document.querySelectorAll("link[rel*='icon']");
    oldIcons.forEach(icon => icon.remove());

    // Create and append new icon
    const newIcon = document.createElement('link');
    newIcon.type = 'image/x-icon';
    newIcon.rel = 'shortcut icon';
    newIcon.href = '/favicon.ico';
    document.head.appendChild(newIcon);

}

// Initialize
changeFavicon();