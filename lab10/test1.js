const assert = require("assert");
const webdriver = require("selenium-webdriver");
const By = webdriver.By;

class MainPage {
	constructor(driver) {
		this.driver = driver;
		this.searchButton = By.xpath('//*[@id="search-form"]/label/i');
		this.textBox = By.xpath('//*[@id="search"]');
	}

	async open() {
		await this.driver.get("https://relouis.by/");
	}

	async performSearch(query) {
		let searchButton = await this.driver.findElement(this.searchButton);
		await searchButton.click();

		let textBox = await this.driver.findElement(this.textBox);
		await textBox.sendKeys(query + "\n");

		await this.driver.sleep(1000);
	}

	async getTitle() {
		return await this.driver.getTitle();
	}

	async quit() {
		await this.driver.quit();
	}
}
async function testRun() {
	const driver = new webdriver.Builder().forBrowser("chrome").build();
	const mainPage = new MainPage(driver);

	try {
		await mainPage.open();
		await mainPage.performSearch("помада");

		let result = await mainPage.getTitle();
		assert.strictEqual(
			"Вы искали помада - Relouis - декоративная косметика",
			result
		);
	} catch (error) {
		console.error("Произошла ошибка:", error.message);
	} finally {
		await mainPage.quit();
		console.log("Test passed!");
	}
}

testRun();
