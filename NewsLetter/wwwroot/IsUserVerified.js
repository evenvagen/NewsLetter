async function simpleUserSearch() {

    const nameInput = document.getElementById("userSearch").value;
    let res = await axios.get('api/newsletter/' + nameInput);


    let getData = res.data.isVerified;

    console.log(res.data);

    document.getElementById("userInfo").innerHTML = getData;

}