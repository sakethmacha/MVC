// Email Custom Validation (Client-Side)
$.validator.addMethod("emailvalidate", function (value, element) {
    if (!value) return true;  // allow empty; [Required] handles null check

    value = value.toLowerCase();

    // Must contain @
    if (value.indexOf("@") === -1) return false;

    let atIndex = value.indexOf("@");

    // Username must exist before @
    if (atIndex === 0) return false;

    // Must end with .com
    if (!value.endsWith(".com")) return false;

    // Extract domain between @ and .com
    let domain = value.substring(atIndex + 1, value.length - 4);

    // Domain required
    if (domain.trim().length === 0) return false;

    // Domain cannot start with dot → @.com invalid
    if (domain.startsWith(".")) return false;

    return true;
});

$.validator.unobtrusive.adapters.add("emailvalidate", [], function (options) {
    options.rules["emailvalidate"] = true;
    options.messages["emailvalidate"] = options.message;
});
