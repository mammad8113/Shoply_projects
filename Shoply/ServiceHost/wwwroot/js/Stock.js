const Notinstock = document.getElementById("NotInStock");

Notinstock.addEventListener("click", e => {
    var id = Notinstock.getAttribute("name");
    fetch(`https://localhost:5001/administration/Shop/Product?id=${id}&handler=NotInStock`)
        .then(response => await response.json())
        .then(json => await console.log(json))
})