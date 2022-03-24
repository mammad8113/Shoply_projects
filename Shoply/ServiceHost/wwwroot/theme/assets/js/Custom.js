const cookieName = "Cart-Item";

function AddToCart(id, name, price, picture) {
    debugger;
    let products = $.cookie(cookieName);
    if (products == undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#ProductCount").val();
    const currentProduct = products.find(x => x.id == id);
    if (currentProduct !== undefined) {
        products.find(x => x.id == id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            Unitprice: price,
            picture,
            count,
        }
        products.push(product);
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" })
    UpdateCart();
}


function formatNum(val) {
    val = Math.round(val * 100) / 100;
    val = ("" + val).indexOf(".") > -1 ? val + "00" : val + ".00";
    var dec = val.indexOf(".");
    return dec == val.length - 3 || dec == 0 ? val : val.substring(0, dec + 3);
}

function ins1000Sep(val) {
    val = val.split(".");
    val[0] = val[0].split("").reverse().join("");
    val[0] = val[0].replace(/(\d{3})/g, "$1,");
    val[0] = val[0].split("").reverse().join("");
    val[0] = val[0].indexOf(",") == 0 ? val[0].substring(1) : val[0];
    return val.join(".");
}

function rem1000Sep(val) {
    return val.replace(/,/g, "");
}

function UpdateCart() {
    debugger;
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#Cart-Item-count").text(products.length);

    let cartItemWrapper = $("#Cart-item-wrapper");
    cartItemWrapper.html('');

    products.forEach(p => {
        let product = `  <div class="single-cart-item">
                              <a href="javascript:void(0)" class="remove-icon" onclick="RemoveItemFormCart(${p.id})">
                                  <i class="ion-android-close"></i>
                              </a>
                              <div class="image">
                                  <a>
                                      <img src="/Upload/${p.picture}"
                                           class="img-fluid" alt="">
                                  </a>
                              </div>

                              <div class="content">
                                  <p class="product-title">
                                      <a href="single-product.html">${p.name}</a>
                                  </p>
                                  <p class="count"><span>تعداد:${p.count}</p>
                                  <p class="count"><span>قیمت واحد:${ins1000Sep(p.Unitprice)}تومان</p>
                              </div>
                          </div>`;

        cartItemWrapper.append(product);
    })
}

function RemoveItemFormCart(id) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);

    var indexitem = products.findIndex(x => x.id == id);
    products.splice(indexitem, 1);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" })
    UpdateCart();
}


function ChangItemCount(id, totalId, count) {
    debugger;
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    let productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    var product = products[productIndex];
    let newTotalPrice = parseInt(product.count) * parseInt(product.Unitprice);
    $(`#${totalId}`).text(newTotalPrice);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" })
    UpdateCart();

}