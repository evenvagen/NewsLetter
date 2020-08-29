
if (window.location.search.includes("email") && window.location.search.includes("code") && window.location.search.includes("name")) {
    ConfirmSubscription();
}


async function ConfirmSubscription() {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);

    const Email = urlParams.get("email");
    const code = urlParams.get("code");
    const Name = urlParams.get("name");


    var response = await axios({
        method: 'patch',
        url: '/api/newsletter',
        data: {
            name: Name,
            email: Email,
            verificationCode: code
        }
    });

}
