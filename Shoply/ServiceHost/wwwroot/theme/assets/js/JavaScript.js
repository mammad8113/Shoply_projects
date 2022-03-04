const option = document.querySelector("select");
const input = document.getElementById("slug");
let s = [];

const div = document.getElementById("product");

option.addEventListener("change", e => {
    let value = option.value;
    let slug = input.value;

    fetch(`https://localhost:5001/ProductCategory/${slug}?number=${value}&p=1&handler=Page`)
        .then(response => console.log(response.json()))
        .then(newresponse => console.log(newresponse))
   
})

