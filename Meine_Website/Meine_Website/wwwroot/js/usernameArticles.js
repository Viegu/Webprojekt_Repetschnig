

$(document).ready(() => {
    $.ajax({
        url: "/shop/UsernameArticles", method: "GET",
        success: (data) => {
          
            if (data == "Fehler!") {
                $("#Fehler").text("Du hast keine Artikel!");
            } else if (data == "DBFehler!") {
                $("#Fehler").text("Fehler bei Datenverarbeitung!!!");
            } else {
                $("#Richtig").html(createAusgabe(data));
            }

        },
        error: () => {
            $("#Fehler").text("Es trat ein Fehler auf - die Artikel konnten nicht geladen werden!");
        }

    });
    $("#b1").click(() => {
        $("#Richtig").toggle()
        $("#alle").toggle()

    })



});

function createAusgabe(articles) {
    let s = ` `;
    s += `  <h3 style="text-align:center">Deine Artikel/Dienstleistungen</h3>`
    for (let i = 0; i < articles.length; i++) {
        s += `<div class="grids">   
                         <h1>${articles[i].articleName}</h1>
                         <p>${articles[i].description}</p>
                         <h5>${articles[i].price}€</h5>
                         <p class="username"${articles[i].username}<p>

 <form action="/shop/delete/${articles[i].article_id}" method="post">
                        <input type="submit" value="löschen" />
                    </form>
              </div> `;
        
    }
    s += ``;

    return s;
}
 






