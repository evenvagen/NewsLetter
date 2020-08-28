async function verifyUser() {

    var result = await axios({
        method: 'patch',
        url: '/api/newsletter',
        data: {
            name: "testuser",
            email: "testuser@mail.net",
            VerificationCode: "f262bfb3-a43e-4b25-bbc2-4656a57989ca"
        }
    });

    if (result.data === true) {
        console.log("Brukeren er verifisert");
    }
}