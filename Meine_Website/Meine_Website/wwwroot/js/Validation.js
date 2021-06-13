

function validation(){
    let nameLenght = document.getElementById("articlename").value;
    let descLenght = document.getElementById("description").value;
    let positivePrice = document.getElementById("artprice").value;



    if (nameLenght.length <= 5) {
        $("#nameError").text("Der Artikelname muss in mehr als 5 Zeichen angegeben werden")
        return false;
    } else {
        $("#nameError").text("");

    }
    if (descLenght.length <= 20) {
        $("#descError").text("Der Artikel muss mit mehr als 20 Zeichen beschrieben werden")
        return false;
    } else {
        $("#descError").text("");
    }
    if (positivePrice < 0) {
        $("#priceError").text("Der Artikel muss mind. 1€ kosten")
        return false;
    } else {
        $("#priceError").text("");
    }

}