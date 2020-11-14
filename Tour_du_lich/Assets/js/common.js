var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();


changeCurrency = (input) => {
    delay(function () {
        var num = input.value.replace(/\D/g, '');
        let x = parseFloat(num);
        if (isNaN(x)) {
            x = 0;
        }
        let a =  x.toLocaleString();
        console.log(a);
        input.value = a;
    }, 800);
}