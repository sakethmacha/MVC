// Custom Password Validation (Client-Side)
$.validator.addMethod("password", function (value, element) {
    if (!value) return true; // allow empty if [Required] not applied

    // Must be more than 8 characters
    if (value.length <= 8) return false;

    // Must contain at least one special character
    var hasSpecialChar = /[^a-zA-Z0-9]/.test(value);
    if (!hasSpecialChar) return false;

    return true;
});

$.validator.unobtrusive.adapters.add("password", [], function (options) {
    options.rules["password"] = true;
    options.messages["password"] = options.message;
});
