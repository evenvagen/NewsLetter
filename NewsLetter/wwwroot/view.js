function htmlView() {
    document.getElementById("app").innerHTML = `

<div id="registrer">
 <input type="text" id="name" placeholder="Navn" /> <br/>
 <input type="text" id="email" placeholder="Epost" /> <br/>
 <input type="button" value="Meld på" onclick="subscribe()" /> <br/>
 <tt style="color:blue" id="wentok"></tt>
</div>



<div id="verifyCheck">
<input type="text" id="userSearch" value="hello"/> <br/>
<button onclick="simpleUserSearch()">Søk opp!</button><br/>
<tt id ="userInfo"></tt>
</div>



<br/>
<button class="verifyButton" onclick="verifyUser()">Verifiser hardkoda bruker!</button>
<tt id="verified"></tt>`;
}
