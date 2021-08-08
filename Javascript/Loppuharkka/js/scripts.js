//Muuttujat koodin luettavuuden parantamiseksi

let input = document.getElementById("submit"); 
let oikeakol= document.getElementById("oikea");
let vasenkol= document.getElementById("vasen");
//Komennot arrayssa
let komennot = ["google", "listaa", "tee popup", "luku", "soita", "Kalle", "vaihda", "funktio", "uusiks"];
//Äänitiedosto
let aani = new Audio("./assets/mixkit-arcade-retro-game-over-213.wav");
//Muuttujaan talletettu #ilmestynyt divin "kadottaminen" klikatessa diviä tai ruksia
let ilmestynyt = 'document.getElementById("ilmestynyt").style.display="none"';
document.getElementById("haku").defaultValue="listaa"
//Varsinainen toteutus
//Syötettävät komennot evaluoidaan:
input.addEventListener("click", function(e){
    e.preventDefault();
    //Hakupalkin value- muuttuja - myöhemmin "arvo"
    let arvo = document.getElementById("haku").value;
    if(arvo == "google"){
        //Avaa googlen uudessa välilehdessä
        oikeakol.innerHTML = "<a href='https://www.google.com'target='_blank'>Siirrytäänkö Googleen?</a>"
    }
        else if(arvo == "listaa"){
            //Listaa klikattavat komennot arraysta foreach-loopilla vasempaan kolumniin
            document.getElementById("vasen").innerHTML = ""
            komennot.forEach(listausFunktio);
        }
        else if(arvo == "Kalle" || arvo == "kalle" ){
            //Oma kuva oikeaan kolumniin
            oikeakol.innerHTML = "<img src = './assets/kuva.jpg' style = 'max-width:450px;max-height:450px'>"
        }
        else if(arvo > 0 && arvo < 1000){
            //Arvon ollessa luku väliltä 1-999 listaa for-loopilla kyseisen määrän rivejä
            document.getElementById("vasen").innerHTML = ""
            for (let i = 0; i < arvo; i++) {
                vasenkol.innerHTML += "<p>" + i + " Generoitua tekstiä </p>"   
            }
        }
        else if(arvo == "soita"){
            //Soittaa muuttujaan tallennetun äänitiedoston
            aani.play();
        }
        else if(arvo == "tee popup"){
            //Luo uuden #ilmestynyt divin ja poistaa ne näkyvista klikatessa - "pyydetty" sana lihavoitu
            oikeakol.innerHTML = '<div id = "ilmestynyt" onclick ='+ ilmestynyt +'>Tässä <b>pyydetty</b> popup<span id = "close" onclick ='+ ilmestynyt +'>X</span></div>';
        }
        else if (arvo == "vaihda"){
            //Taustavärin vaihto punaiseksi
            document.body.style.backgroundColor = "red"
        }
        else if(arvo == "funktio"){
            //Lisää oikeaan kolumniin funktion, joka ilmoittaa konsoliin funktion toimivuudesta sekä suorittaa annetut komennot funktion "suorita" mukaisesti 
            console.log("Funktio toimii");
            oikeakol.innerHTML = "<form><input type='text' name='haku2' id='haku2' style='height:40px;width:300px;margin:10px;'>"
            oikeakol.innerHTML += "<input type='submit' value='Suorita'id='submit2' style='width:100px;height:25px;margin-left:10px;'></input></form>"
            document.getElementById("submit2").addEventListener("click",()=> suoritus());
        }
        else if(arvo == "uusiks"){
            //Päivittää sivun
            window.location.reload();
        }
        else{
            //Ilmoitus komennon tunnistamattomuudesta
            oikeakol.innerHTML = "<p style='font-size:2em;'>Komentoa ei tunnistettu</p>"
        }
});

function suoritus(){
    //Tehtävänannon mukaiset toiminnallisuudet - evaluoi annettua syötettä ja toimii sen mukaisesti
    if (document.getElementById("haku2").value == "") {
        console.log("anna komento")
    }
    else if(document.getElementById("haku2").value == "reload"){
        window.location.reload();
    }
    else{
        console.log("Kirjoitit: " + document.getElementById("haku2").value)
    }
}

//Arvon ollessa "listaa", luo loopilla aina uuden klikattavan elementin vasempaan kolumniin ja muuttaa hakukentän arvon linkkiä klikattaessa

function listausFunktio(jasen){
    document.getElementById("vasen").innerHTML += "<a href = '#' id='"+jasen+"' onclick='palautus(this.id)' >" + jasen + "</a><br>";
    console.log(jasen);
}
function palautus(klikatun_id){
    //Jos klikattu kohde on "luku", arvotaan hakukenttän arvoksi luku 1-999 väliltä
    if (klikatun_id ==  "luku") {
        document.getElementById("haku").value = Math.floor((Math.random() * 999) + 1);
    }
    //Arvon ollessa joku muu kuin luku, hakukentän arvoksi klikatun elementin id
    else{
        document.getElementById("haku").value = klikatun_id;
    }
}
