const loader = document.getElementById("loader");
const app = document.getElementById("app");

fadeToAppScreenWhenReady();

/**
 * When app has finished loading,
 * hides the loader and reveals the app
 * using animations.
 **/
async function fadeToAppScreenWhenReady()
{
    while (app.childElementCount == 0)
    {
        await sleep(100);
    }

    loader.classList.add("hide");

    await sleep(500);

    loader.parentNode.removeChild(loader);
    app.classList.remove("hide");
    app.classList.add("appear");
}

/**
 * 
 * @ms - delay in miliseconds (integer)
 **/
function sleep(ms)
{
    return new Promise(resolve => setTimeout(resolve, ms));
}
