// const { Builder, By } = require("selenium-webdriver");
// const { assert } = require("chai");

// class MainPage {
// 	constructor(driver) {
// 		this.driver = driver;
// 		this.searchButton = By.xpath('//*[@id="search-form"]/label/i');
// 		this.textBox = By.xpath('//*[@id="search"]');
// 	}

// 	async open() {
// 		await this.driver.get("https://relouis.by/");
// 	}

// 	async performSearch(query) {
// 		let searchButton = await this.driver.findElement(this.searchButton);
// 		await searchButton.click();

// 		let textBox = await this.driver.findElement(this.textBox);
// 		await textBox.sendKeys(query + "\n");

// 		await this.driver.sleep(1000);
// 	}

// 	async getTitle() {
// 		return await this.driver.getTitle();
// 	}

// 	async quit() {
// 		await this.driver.quit();
// 	}
// }

// describe("MainPage", async () => {
// 	let driver;
// 	let mainPage;

// 	driver = await new Builder().forBrowser("chrome").build();
// 	mainPage = new MainPage(driver);
// 	await mainPage.open();

// 	it("should perform search and check the title", async () => {
// 		this.timeout(10000);
// 		await mainPage.performSearch("помада");

// 		const result = await mainPage.getTitle();
// 		assert.strictEqual(
// 			result,
// 			"Вы искали помада - Relouis - декоративная косметика",
// 			"Title doesn't match"
// 		);
// 	});
// 	await mainPage.quit();
// });
// /*
// async function testRun(){
// let driver;
// let mainPage;

//     before(async () => {
// 			driver = await new Builder().forBrowser("chrome").build();
// 			mainPage = new MainPage(driver);
// 			await mainPage.open();
// 		}, 1000000);

// 		after(async () => {
// 			await mainPage.quit();
// 		}, 10000000);
// }
// */
const assert = require("assert");
const { Builder, By } = require("selenium-webdriver");
const { describe, it, before, after, done } = require("mocha");

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

describe("MainPage", () => {
	let driver;
	let mainPage;

	before(() => {
		setTimeout(async () => {
			driver = await new Builder().forBrowser("chrome").build();
			mainPage = new MainPage(driver);
			await mainPage.open();
		}, 2000);
	});

	after(() => {
		setTimeout(async (done) => {
			await mainPage.quit().then(() => done(), done);
		}, 2000);
	});

	// after((done) => {
	// 	mainPage.quit().then(() => done(), done); // использование промиса и done
	// });

	it("should perform search and check the title", function () {
		setTimeout(() => {
			mainPage.performSearch("помада").then(async () => {
				const result = await mainPage.getTitle();
				assert.strictEqual(
					result,
					"Вы искали помада - Relouis - декоративная косметика",
					"Title doesn't match"
				);
			});
		}, 5000);
	});

	// it("should perform search and check the title", (done) => {
	// 	// Обратите внимание на done
	// 	mainPage
	// 		.performSearch("помада")
	// 		.then(async () => {
	// 			const result = await mainPage.getTitle();
	// 			assert.strictEqual(
	// 				result,
	// 				"Вы искали помада - Relouis - декоративная косметика",
	// 				"Title doesn't match"
	// 			);
	// 			done(); // Вызываем done по завершении теста
	// 		})
	// 		.catch((error) => {
	// 			done(error); // Передаем ошибку в done в случае возникновения ошибки
	// 		});
	// });

	// it("should perform search and check the title", async () => {
	// 	await mainPage.performSearch("помада");

	// 	const result = await mainPage.getTitle();
	// 	assert.strictEqual(
	// 		result,
	// 		"Вы искали помада - Relouis - декоративная косметика",
	// 		"Title doesn't match"
	// 	);
	// });
});
