async function verifyUser() {

    var result = await axios({
        method: 'patch',
        url: '/api/newsletter',
        data: {
            name: "johnny",
            email: "johnny@gmail.com",
            verificationCode: "4b08e113-1ffd-4e3f-91a6-ce4fe2c027ff"
        }
    });

    if (result.data === true) {
        document.getElementById("verified").innerHTML = "<br/>" + "Brukeren er verifisert";
    }
}