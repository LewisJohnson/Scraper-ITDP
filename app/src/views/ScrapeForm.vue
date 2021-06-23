<template>
	<div class="col-12 col-md-6 col-lg-8 mt-4 px-5">
		<h2>
			<span class="g g-blue">G</span>
			<span class="g g-red">o</span>
			<span class="g g-yellow">o</span>
			<span class="g g-blue">g</span>
			<span class="g g-green">l</span>
			<span class="g g-blue">e</span> Results Scraper
		</h2>
		<form method="POST" v-on:submit="SubmitForm" class="mb-5">
			<div class="mb-3">
				<label for="Keywords" class="form-label">Keywords</label>
				<input
					v-model="keywords"
					id="Keywords"
					type="text"
					class="form-control"
					v-bind:disabled="isLoading"
				/>
				<div class="form-text">
					The keywords to use for the Google Search.
				</div>
			</div>

			<div class="mb-3">
				<label for="URL" class="form-label">URL</label>
				<input
					v-model="url"
					id="Url"
					type="text"
					class="form-control"
					v-bind:disabled="isLoading"
				/>
				<div class="form-text">
					The URL to look for in the top 100 results.
				</div>
			</div>

			<input
				class="btn btn-primary mt-2"
				type="submit"
				value="Go 🚀"
				v-bind:disabled="isLoading"
			/>
		</form>

		<div v-if="isLoading" class="text-center">
			<div class="spinner-border" role="status">
				<span class="visually-hidden">Loading...</span>
			</div>

			<p>Just fetching the results for you...</p>
		</div>

		<div v-if="hasLoaded">
			<h3>Results</h3>
			<div>We searched Google with the term(s) <b>{{ searchedKeywords }}</b> and looked for results containg the URL <b>{{ searchedUrl }}</b>.</div>
			<h5 class="mt-4 ">We found <i>{{ results.length }}</i> results, here's the full URLs</h5>

			<ul class="list-group list-group-flush">
				<li v-for="res in results" v-bind:key="res" class="list-group-item">
					{{ res }}
				</li>
			</ul>
		</div>

		<div v-if="hasError" class="bg-danger text-white p-2 rounded">
			<h3>Sorry, we've run into a problem ☹</h3>
			<hr />
			<p>{{ errorMessage }}</p>
		</div>
	</div>
</template>

<style scoped>
	.spinner-border {
		width: 4rem;
		height: 4rem;
	}

	/* Used short names to avoid using company name in code */
	.g {
		font-weight: 600;
	}

	.g-blue {
		color: #4285f4;
	}

	.g-red {
		color: #db4437;
	}

	.g-yellow {
		color: #f4b400;
	}

	.g-green {
		color: #0f9d58;
	}

	input[type="submit"]:hover {
		animation: shake 0.82s cubic-bezier(0.36, 0.07, 0.19, 0.97) both;
		transform: translate3d(0, 0, 0);
		backface-visibility: hidden;
		perspective: 1000px;
	}

	@keyframes shake {
		10%,
		90% {
			transform: translate3d(-1px, -1px, 0);
		}

		20%,
		80% {
			transform: translate3d(2px, -2px, 0);
		}

		30%,
		50%,
		70% {
			transform: translate3d(-2px, -3px, 0);
		}

		40%,
		60% {
			transform: translate3d(4px, -4px, 0);
		}
	}
</style>

<script>
	const data = {
		// Form data
		url: "",
		keywords: "",
		results: "",

		// Page data
		searchedUrl: "",
		searchedKeywords: "",
		isLoading: false,
		hasLoaded: false,
		hasError: false,

		errorMessage: "",
	};

	export default {
		data() {
			return data;
		},
		methods: {
			SubmitForm: function (e) {
				e.preventDefault();

				this.AxiosPending();

				let payload = JSON.stringify({
					url: this.url,
					keywords: this.keywords,
				});

				this.axios
					.post("Scraper", payload, {
						headers: { "Content-Type": "application/json" },
					})
					.then((res) => {
						this.results = res.data;
						this.AxiosLoaded();
					})
					.catch((err) => {
						this.errorMessage = err.message;
						this.AxiosError();
					});
			},
			AxiosPending: function () {
				this.isLoading = true;
				this.hasLoaded = false;
				this.hasError = false;

				this.searchedUrl = '';
				this.searchedKeywords = '';
			},
			AxiosLoaded: function () {
				this.isLoading = false;
				this.hasLoaded = true;
				this.hasError = false;

				this.searchedUrl = this.url;
				this.searchedKeywords = this.keywords;
			},
			AxiosError: function () {
				this.isLoading = false;
				this.hasLoaded = false;
				this.hasError = true;
			},
		},
	};
</script>