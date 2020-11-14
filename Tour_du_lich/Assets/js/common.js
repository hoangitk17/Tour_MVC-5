changeCurrency = (input) => {
    let x = input.value;
    xCultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
    let a = double.Parse(x).ToString("#,###", cul.NumberFormat);
    console.log(a);
    input.value = a;
}