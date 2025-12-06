

$.validator.addMethod("nonumbers", function (value, element) {
    if (!value) return true;
    return !/\d/.test(value);
});

$.validator.unobtrusive.adapters.add("nonumbers", [], function (options) {
    options.rules["nonumbers"] = true;
    options.messages["nonumbers"] = options.message;
});
