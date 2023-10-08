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

function autoLogout() {
    var form = document.createElement('form');
    form.method = 'post';
    form.action = '/logout'; // Assuming this is the correct URL

    var csrfToken = document.getElementsByName('__RequestVerificationToken')[0].value;
    var csrfInput = document.createElement('input');
    csrfInput.type = 'hidden';
    csrfInput.name = '__RequestVerificationToken';
    csrfInput.value = csrfToken;

    form.appendChild(csrfInput);

    document.body.appendChild(form);
    form.submit();
}