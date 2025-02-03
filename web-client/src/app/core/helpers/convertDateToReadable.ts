export function convertDateToReadable(reviewDate: Date, abbreviate: boolean) {
  // 'T' separates the date and time in the ISO 8601 DateTime format
  const dateTimeList: string[] = reviewDate.toString().split('T');
  const date = dateTimeList[0];
  const dateList: string[] = date.split('-');
  const year: string = dateList[0];
  const month: string = dateList[1];
  const day: string = dateList[2];
  let readableMonth: string = '';
  switch (month) {
    case Months.January:
      readableMonth = 'January';
      break;
    case Months.February:
      readableMonth = 'February';
      break;
    case Months.March:
      readableMonth = 'March';
      break;
    case Months.April:
      readableMonth = 'April';
      break;
    case Months.May:
      readableMonth = 'May';
      break;
    case Months.June:
      readableMonth = 'June';
      break;
    case Months.July:
      readableMonth = 'July';
      break;
    case Months.August:
      readableMonth = 'August';
      break;
    case Months.September:
      readableMonth = 'September';
      break;
    case Months.October:
      readableMonth = 'October';
      break;
    case Months.November:
      readableMonth = 'November';
      break;
    case Months.December:
      readableMonth = 'December';
      break;
  }

  if (abbreviate) {
    readableMonth = readableMonth.slice(0, 3);
  }

  return `${readableMonth} ${day}, ${year}`;
}

enum Months {
  January = '01',
  February = '02',
  March = '03',
  April = '04',
  May = '05',
  June = '06',
  July = '07',
  August = '08',
  September = '09',
  October = '10',
  November = '11',
  December = '12',
}
