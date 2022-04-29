const cookieName = "Cart-Item";

function AddToCart(id, name, price, priceWithdiscount, picture) {
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
            priceWithdiscount,
            count,
            picture
        }
        products.push(product);
    }
    var countproduct = products.find(x => x.id == id).count;
    const settings = {
        "url": "https://iranshoply.ir/api/Inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "productId": id, "count": parseInt(countproduct) })
    };

    $.ajax(settings).done(function (data) {
        if (data.isInstock == true) {
            $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
            UpdateCart();
        } else {
            alert(" تعداد درخواستی از موجودی در انبار کمتر است.");
        }
    });
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

    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#Cart-Item-count").text(products.length);

    let cartItemWrapper = $("#Cart-item-wrapper");
    cartItemWrapper.html('');
    products.forEach(p => {
        var productWithdiscount = (p.priceWithdiscount > 0) ? true : false;
        let product = ``;
        if (productWithdiscount) {
            product = `  <div class="single-cart-item">
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
                                  <p class="count">قیمت واحد:<del class="main-price">${ins1000Sep(p.Unitprice)} تومان</del></p>
                                  <p class="count" style="color:red;">قیمت: ${ins1000Sep(p.priceWithdiscount)}تومان </span></p>
                              </div>
                          </div>`;
        } else {
            product = `  <div class="single-cart-item">
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
                                  <p class="count">قیمت واحد:<span class="main-price">${ins1000Sep(p.Unitprice)} تومان</span></p>
                              </div>
                          </div>`;
        }
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

    const settings = {
        "url": "https://iranshoply.ir/api/Inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "productId": id, "count": count })
    };

    $.ajax(settings).done(function (data) {
        if (data.isInstock == false) {
            debugger;
            const warningsDiv = $('#productStockWarnings');
            if ($(`#${id}`).length == 0) {
                warningsDiv.append(`
                    <div class="alert alert-warning" id="${id}">
                        <i class="fa fa-warning"></i> کالای
                        <strong>${data.product}</strong>
                        در انبار کمتر از تعداد درخواستی موجود است.
                    </div>
                `);
            }
        } else {
            if ($(`#${id}`).length > 0) {
                $(`#${id}`).remove();
            }
        }
    });


}
async function SetCity(stateId) {
    debugger;

    let response = await fetch(`https://iranshoply.ir/CheckOut?id=${stateId}&handler=City`)
    let data = await response.json();
    var cities = document.getElementById("City");
    cities.options.length = 0;
    for (i = 0; i < data.length; i++) {
        if (data[i] != "") {
            cities.options[cities.options.length] = new Option(data[i].name, data[i].id);
        }
    }

}

function Set() {
    debugger;
    var value = $("#State").val();
    var c = document.getElementById("City");
    c.addEventListener("click", e => {
        debugger;
        SetCity(value);

    });
};




var minutes;
var seconds;
var set_inteval;
function otp_timer() {
    seconds -= 1;
    document.getElementById('seconds').innerHTML = seconds;
    document.getElementById('minutes').innerHTML = minutes;
    if (seconds == 0) {
        if (minutes > 0) {
            seconds = 60;
            minutes -= 1;
        } else {
            minutes = 0;
            document.getElementById('minutes').innerHTML = minutes;
            clearInterval(set_inteval);
            minutes = 0;
            seconds = 0;
            document.getElementById('seconds').innerHTML = '00';
            document.getElementById('minutes').innerHTML = '0';
            var div = document.getElementById("CodeWrapper");
            div.style.display = "none"
            document.getElementById("BtnMobile").style.display = "none";
            document.getElementById("BtnGetcode").style.display = "block";
        }
    }
}


function startTimer() {
    minutes = 1;
    seconds = 10;
    document.getElementById('seconds').innerHTML = seconds;
    document.getElementById('minutes').innerHTML = minutes;
    set_inteval = setInterval('otp_timer()', 1000);
}



let code;
let Id;
async function GetPassword() {
    debugger;
    var mobile = $("#Mobile").val();
    let response = await fetch(`https://iranshoply.ir/api/Acount`, {
        method: "Post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ "Mobile": mobile })
    });

    var data = await response.json();
    if (data.isSuccedded) {
        document.getElementById("ErrorMessage").style.display="none";
        code = data.code;
        Id = data.id;
        var div = document.getElementById("CodeWrapper");
        div.style.display = "block"
        var BtnGetcode = document.getElementById("BtnGetcode");
        BtnGetcode.style.display = "none";
        var BtnMobile = document.getElementById("BtnMobile");
        BtnMobile.style.display = "block";
        startTimer();
    } else {
        let ErrorMessage = document.getElementById("ErrorMessage");
        ErrorMessage.innerHTML = `${data.message}`
        ErrorMessage.style.display = "block";
    }
};

function CheckCode() {
    debugger;
    var Code = $("#Code").val();
    if (Code == code) {
        window.location.href = `https://iranshoply.ir/ChangPassword/${Id}`;
    } else {
        document.getElementById("ErrorMessage").style.display = "block";
        $("#ErrorMessage").text("کد ورودی اشتباه است");
    }
};

function ChangMobile() {
    debugger;
    document.getElementById("BtnMobile").style.display = "none";
    document.getElementById("CodeWrapper").style.display = "none";
    document.getElementById("BtnGetcode").style.display = "block";
    clearInterval(set_inteval);

}



