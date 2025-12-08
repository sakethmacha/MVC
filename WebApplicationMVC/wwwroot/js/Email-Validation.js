// Email Custom Validation (Client-Side using Regex)
$.validator.addMethod("emailvalidate", function (value, element) {

    if (!value) {
        return true; // Let [Required] handle empty values
    }

    // Same regex as server-side validation
    var pattern = /^[A-Za-z0-9]+@[A-Za-z]+\.com$/;

    return pattern.test(value);
});

$.validator.unobtrusive.adapters.add("emailvalidate", [], function (options) {
    options.rules["emailvalidate"] = true;
    options.messages["emailvalidate"] = options.message;
});
