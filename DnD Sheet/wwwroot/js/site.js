const favicon = document.getElementById('favicon');
const isDark = window.matchMedia('(prefers-color-scheme: dark)');

const changeFavicon = () => {
    if (isDark.matches)
        favicon.href = "/whiteLogo.svg";
    else
        favicon.href = "/blackLogo.svg";
}

const toggleMode = () => {
    const body = document.body;
    const currentMode = body.classList.contains('dark-mode') ? 'dark' : 'light';
    const newMode = currentMode === 'dark' ? 'light' : 'dark';

    body.classList.remove(`${currentMode}-mode`);
    body.classList.add(`${newMode}-mode`);

    localStorage.setItem('modePreference', newMode);
}

const setInitialMode = () => {
    changeFavicon()
    const preferredMode = localStorage.getItem('modePreference') || 'light';
    document.body.classList.add(`${preferredMode}-mode`);
}

document.getElementById('switchLightMode').addEventListener('click', toggleMode);
setInitialMode();