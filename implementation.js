
const paymentMethodsResponse = JSON.parse(
    document.getElementById("paymentMethodsResponse").innerHTML
);


const configuration = {
    paymentMethodsResponse,
    clientKey: "test_7ZCG2HRVQ5DYDG54CTVFVXKYFIKWXTBF",
    locale: "en_US",
    environment: "test",
    paymentMethodsConfiguration: {
        card: {
            hasHolderName: true,
            holderNameRequired: true,
            enableStoreDetails: true,
            hideCVC: false, 
            name: 'Credit or debit card',
            //billingAddressRequired: true,
        },
        threeDS2: { 
            challengeWindowSize: '05'
            // Set to any of the following:
            // '02': ['390px', '400px'] -  The default window size
            // '01': ['250px', '400px']
            // '03': ['500px', '600px']
            // '04': ['600px', '400px']
            // '05': ['100%', '100%']
        },
    },
    onSubmit: (state, component) => {
        makePayment(state, component, "/Home/Pay")

    },
    onAdditionalDetails: (state, component) => {
        //makeDetailsCall(state, component, "/api/HandleRedirect");
    },
};

async function callServer(url, data) {
    try {
        const response = await fetch(url, {
            method: "POST",
            body: JSON.stringify({'data': data}),
            headers: {
                "Content-Type": "application/json"
            },
        });
        return response.json();

    } catch (error) {
        console.error(error);
    }
}


function handleServerResponse(res, component) {

    if (res.action) {
        component.handleAction(res.action);
    } else {
        switch (res.resultCode) {
            case "Authorised":
                window.location.href = "/Home/success";
                break;
            case "Pending":
                window.location.href = "/Home/pending";
                break;
            case "Refused":
                window.location.href = "/Home/failed";
                break;
            default:
                window.location.href = "/Home/error";
                break;
        }
    }
}


async function makePayment(state, component, url) {
    try {
        const response = await callServer(url, state.data);
        return handleServerResponse(response, component);
    } catch (error) {
        console.error(error);
    }
}

const checkout = new AdyenCheckout(configuration);

const integration = checkout
    .create("dropin", {
        openFirstPaymentMethod: true
    })
    .mount(document.getElementById("dropin-container"));
