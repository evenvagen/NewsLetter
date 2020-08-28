async function subscribe() {

    var nameInput = document.getElementById("name").value;
    var emailInput = document.getElementById("email").value;

    document.getElementById("wentok").innerHTML = "...";

    const result = await axios.post('/api/newsletter', { name: nameInput, email: emailInput });

    if (result.status === 200 || result.status === 201 || result.status === 202 || result.status === 204) {
        document.getElementById("wentok").innerHTML = "Registrert! Sjekk epost for å verifisere";
    }
    console.log(result);

}
