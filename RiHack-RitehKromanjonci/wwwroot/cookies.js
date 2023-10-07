function setEmailCookie(email, expirationInSeconds) {
    const options = {
        expires: new Date(Date.now() + (expirationInSeconds * 1000)), // Set expiration in seconds
        path: '/' // Specify the path for the cookie
    };

    const encodedEmail = encodeURIComponent(email);
    document.cookie = `Email=${encodedEmail}; ${Object.entries(options).map(([key, value]) => `${key}=${value}`).join('; ')}`;
}

function getEmailFromCookie() {
    const cookies = document.cookie.split(';');
    for (let i = 0; i < cookies.length; i++) {
        const cookie = cookies[i].trim();
        if (cookie.startsWith('Email=')) {
            return decodeURIComponent(cookie.substring(6)); // Remove 'Email=' and decode
        }
    }
    return null; // Return null if the cookie is not found
}