document.addEventListener('DOMContentLoaded', function () {
    // Check if the user has a preferred mode stored in localStorage
    const preferredMode = localStorage.getItem('preferredMode');

    // Apply the preferred mode or default to dark mode
    if (preferredMode === 'light') {
        toggleLightMode();
    }

    // Add click event listener to the switchLightMode button
    const switchLightModeButton = document.getElementById('switchLightMode');
    switchLightModeButton.addEventListener('click', function () {
        // Toggle between light and dark modes
        if (document.body.classList.contains('light-mode')) {
            toggleDarkMode();
        } else {
            toggleLightMode();
        }
    });
});

function toggleLightMode() {
    // Add or remove classes to switch to light mode
    document.body.classList.remove('bg-dark', 'text-light');
    document.body.classList.add('bg-light', 'text-dark');

    // Update the preferred mode in localStorage
    localStorage.setItem('preferredMode', 'light');
}

function toggleDarkMode() {
    // Add or remove classes to switch to dark mode
    document.body.classList.remove('bg-light', 'text-dark');
    document.body.classList.add('bg-dark', 'text-light');

    // Update the preferred mode in localStorage
    localStorage.setItem('preferredMode', 'dark');
}
