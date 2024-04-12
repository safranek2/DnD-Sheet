const favicon = document.getElementById('favicon');
const isDark = window.matchMedia('(prefers-color-scheme: dark)');
const buttonMode = document.getElementById('toggleMode');

var ModeIcons = {
    lightMode: '<span class="material-symbols-outlined">light_mode</span>',
    darkMode: '<span class="material-symbols-outlined">dark_mode</span>'
};


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
    buttonMode.innerHTML = ModeIcons[`${newMode}Mode`];
    document.documentElement.setAttribute('data-bs-theme', newMode)

    localStorage.setItem('modePreference', newMode);
};

const setInitialMode = () => {
    changeFavicon();
    const preferredMode = localStorage.getItem('modePreference') || 'light';
    document.body.classList.add(`${preferredMode}-mode`);
    buttonMode.innerHTML = ModeIcons[`${preferredMode}Mode`];
    document.documentElement.setAttribute('data-bs-theme', preferredMode)
};

document.getElementById('toggleMode').addEventListener('click', toggleMode);
setInitialMode();
