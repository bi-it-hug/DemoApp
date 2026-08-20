using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace DemoApp.Services;

public sealed class LocalStorageService(IJSRuntime jsRuntime)
{
	private readonly JsonSerializerOptions _jsonOptions = new(
			JsonSerializerDefaults.Web
	)
	{
		Converters = { new JsonStringEnumConverter() },
	};

	public async ValueTask SetAsync<T>(string key, T value)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(key);
		var json = JsonSerializer.Serialize(value, _jsonOptions);
		await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
	}

	public async ValueTask<T?> GetAsync<T>(string key)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(key);
		var json = await jsRuntime.InvokeAsync<string?>(
				"localStorage.getItem",
				key
		);
		if (string.IsNullOrWhiteSpace(json))
			return default;

		try
		{
			return JsonSerializer.Deserialize<T>(json, _jsonOptions);
		}
		catch (JsonException)
		{
			return default;
		}
	}

	public ValueTask RemoveAsync(string key)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(key);
		return jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
	}
}
