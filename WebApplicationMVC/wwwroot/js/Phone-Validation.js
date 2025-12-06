// Custom Phone Number Validation (Client-Side)
$.validator.addMethod("phonenumber", function (value, element) {
    if (!value) return true; // allow empty; Required attribute handles empty case

    // Must be exactly 10 digits
    if (!/^[0-9]{10}$/.test(value)) return false;

    // Must start with 6, 7, 8, or 9
    var firstDigit = value.charAt(0);
    if (!["6", "7", "8", "9"].includes(firstDigit)) return false;

    return true;
});

$.validator.unobtrusive.adapters.add("phonenumber", [], function (options) {
    options.rules["phonenumber"] = true;
    options.messages["phonenumber"] = options.message;
});
