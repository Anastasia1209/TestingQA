const assert = require("assert");
const webdriver = require("selenium-webdriver");
const By = webdriver.By;

class MainPage {
	constructor(driver) {
		this.driver = driver;
		this.searchButton = By.xpath('//*[@id="header"]/div/nav/ul/li[5]/a');
		this.buyButton = By.xpath(
			'//*[@id="content"]/div/div/div[2]/div/div[1]/div/div/div[2]/div/div/div[2]'
		);
		this.checkBacket = By.xpath('//*[@id="add-to-cart-modal"]/div[1]/div[2]/a');
		this.closeButton = By.xpath('//*[@id="popmake-15630"]/button');
	}

	async open() {
		await this.driver.get("https://relouis.by/");
	}

	async buyProd() {
		let searchButton = await this.driver.findElement(this.searchButton);
		await searchButton.click();

		let buyButton = await this.driver.findElement(this.buyButton);
		await buyButton.click();

		await this.driver.sleep(1000);
		let checkBacket = await this.driver.findElement(this.checkBacket);
		await checkBacket.click();

		await this.driver.sleep(6000);
		let closeButton = await this.driver.findElement(this.closeButton);
		await closeButton.click();

		await this.driver.sleep(1000);
	}

	async quit() {
		await this.driver.quit();
	}
}
it("should be successfully added to cart", async () => {
	const driver = new webdriver.Builder().forBrowser("chrome").build();
	const mainPage = new MainPage(driver);
	await mainPage.open();
	await mainPage.buyProd();
	const cartItems = await driver.findElements(By.className("cart-block-items"));

	assert.strictEqual(cartItems.length, 1);
	console.log(`Assertion passed: Number of cart items is ${cartItems.length}`);
	await mainPage.quit();
});
// async function testRun() {
// 	try {
// 	} catch (error) {
// 		console.error("Произошла ошибка:", error.message);
// 	} finally {
// 		await mainPage.quit();
// 		console.log("Test passed!");
// 	}
// }
// testRun();
