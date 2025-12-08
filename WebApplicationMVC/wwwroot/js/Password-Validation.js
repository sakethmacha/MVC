$.validator.addMethod("password", function (value, element, params) {
    if (!value) return true; // allow empty, 'required' handles empty check
    var pattern = new RegExp(params.pattern);
    return pattern.test(value);
});

$.validator.unobtrusive.adapters.add("password", ["pattern"], function (options) {
    options.rules["password"] = { pattern: options.params.pattern };
    options.messages["password"] = options.message;
});
