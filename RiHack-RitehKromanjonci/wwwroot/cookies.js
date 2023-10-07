function setEmailCookie(email, expirationInSeconds) {
    const options = {
        expires: new Date(Date.now() + (expirationInSeconds * 1000)), // Set expiration in seconds
        path: '/' // Specify the path for the cookie
    };

    const encodedEmail = encodeURIComponent(email);
    document.cookie = `Email=${encodedEmail}; ${Object.entries(options).map(([key, value]) => `${key}=${value}`).join('; ')}`;
}