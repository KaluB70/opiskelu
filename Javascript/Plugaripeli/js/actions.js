console.log("jes!");

let peliruutu = "";

for (let i = 0; i<36;i++){
    peliruutu += "<div id = 'ruutu-" + i + "' class='ruutu' data-ruudunid='"+ i + "'><div>" + i + "</div></div>";
}

document.getElementById("pelilauta").innerHTML= peliruutu;

let topScore = 0;
let topClicks = 0;
let initials;

chrome.storage.sync.get(["initials"], function(result){
    if (result.initials){
        initials = result.initials;
    }
    document.getElementById("nimimerkki").value = initials;
})

document.getElementById("nimimerkki").addEventListener("keyup", function(){
    initials = this.value;
    console.log("initials: "+ initials);
    chrome.storage.sync.set({initials:initials}, function(){});
})


let saveTopScores = (storedTopScores) => {
    console.log("stored", storedTopScores);

    let playerInfo = {
        name:initials,
        topScore:topScore,
        topClicks:topClicks
    }
    console.log(playerInfo);

    storedTopScores.push(playerInfo);

    let storedTopScoreStringified = JSON.stringify(storedTopScores);

    chrome.storage.sync.set({topScores:storedTopScoreStringified}, function(){
        //pian
    });
}

let aarteet = [0,6,12];

function teeYksiPommi() {
    let pommi = Math.floor(Math.random()*36 );
    console.log("pommi tehtiin "+ pommi);
    return pommi;
}

function tarkistaPomminSijainti(pommi) {
    pommiOK = true;
    for (let index = 0; index < aarteet.length; index++) {
        if (pommi == aarteet[index]) {
            pommiOK = false;
        }
    }
    return pommiOK;
}

function teePommit(maara){
    let pommit= [];
    for (let i = 0; i < maara; i++) {
        let pommi = teeYksiPommi();
        if (!tarkistaPomminSijainti(pommi)) {
            pommi = teeYksiPommi();
        }
        pommit.push(pommi)
    }
    return pommit;
}

let joKaydyt = [];

//let pommi = [1,2,3];
let pommi = teePommit(10);
let pisteet = 0;

let ruudut = document.getElementsByClassName("ruutu");
for (let i = 0; i<ruudut.length; i++){
    //console.log("ruutu " + ruudut[i].innerHTML)

    ruudut[i].addEventListener("click",function(){
        //console.log("ruutu " + this.innerHTML);
        console.log("ruutu " + this.dataset.ruudunid);
        let ruudunid = parseInt(this.dataset.ruudunid);
        this.innerHTML = "<div>X</div>";

        let ok = true;
        for(let i = 0; i<joKaydyt.length; i++){
            if(joKaydyt[i] == ruudunid){
                console.log("kerätty jo!")
                ok = false;
            }
            else{
                console.log("saat piseen!");
            }
        }

        if (ok){
            joKaydyt.push(ruudunid);
            pisteet++;

            if(aarteet.includes(ruudunid)){
                pisteet += 9;

                let kissakuva = document.createElement("img");
                kissakuva.src = "https://media.giphy.com/media/vFKqnCdLPNOKc/giphy.gif"
                this.appendChild(kissakuva);
            }

            if(pommi.includes(ruudunid)){
                pisteet -= 21;

                let pommikuva = document.createElement("img");
                pommikuva.src = "https://media.giphy.com/media/XrNry0aqYWEhi/giphy.gif"
                this.appendChild(pommikuva);
            }

            document.getElementById("pisteet").innerHTML = pisteet;

            if (topScore < pisteet) {
                topScore = pisteet;
                console.log("top score current " + topScore);
            }
            topClicks++;
            }

        if (pisteet < 0){
            console.log("hävisit!");

            let storedTopScores = [];

            //haetaan lista
            chrome.storage.sync.get(["topScores"],function(result){
                if(result.topScores){
                    storedTopScores = JSON.parse(result.topScores);
                }
                else{
                    console.log("ei pisteitä");
                }
                saveTopScores(storedTopScores);
            })

            let haviopopup = document.createElement("div");
            haviopopup.id = "popup";
            haviopopup.innerHTML = "<h1>Ei hyvin menny...</h1>";
            haviopopup.innerHTML += "<p>Pisteet: " + pisteet + "</p>";
            haviopopup.innerHTML += "<button id = 'uudestaan'>Uudelleen</button>";
            haviopopup.onclick = () => window.location.reload();

            haviopopup.style.opacity = 0;

            setTimeout(function(){
                haviopopup.style.opacity = 1;
            }, 500);

            document.body.appendChild(haviopopup);
        }
    });
}