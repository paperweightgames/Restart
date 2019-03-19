using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TimeDisplay : MonoBehaviour
	{
		[SerializeField] private TimeCycle timeCycle;
		[SerializeField] private Text dayText;
		[SerializeField] private Text timeText;

		private void Update()
		{
			// Day.
			var formattedDay = Mathf.Ceil(timeCycle.GetTime() / timeCycle.GetDayLength());
			dayText.text = string.Format("Day {0}", formattedDay);
			// Time.
			var currentTime = timeCycle.GetTime() % timeCycle.GetDayLength() / timeCycle.GetDayLength() * 24;
			var currentHour = Mathf.Floor(currentTime);
			var currentMinute = Mathf.Floor((currentTime - currentHour) * 60);
			var paddedHour = currentHour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
			var paddedMinute = currentMinute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
			timeText.text = string.Format("{0}:{1}", paddedHour, paddedMinute);
		}
	}
}
